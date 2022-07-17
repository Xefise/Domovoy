import {useAuth} from "../components/AuthProvider";
import React, {ChangeEvent, useContext, useEffect, useState} from "react";
import {
    ApartmentHouseDetails,
    ConstructionCompanyDetails,
    ConstructionCompanyService,
    HouseEntranceDetails,
    SmartHomeDeviceType
} from "../api";
import {upVariants} from "../animations";
import {AnimatePresence, motion} from "framer-motion";
import {addressToString} from "../addressToString";
import {Link, useLocation, useOutlet} from "react-router-dom";

import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import '../styles/menu.css';
import '../styles/AdminIndexPage.scss';

export interface Props {

}


export interface Storage {
    comapny?: ConstructionCompanyDetails,
    entances: Record<number, HouseEntranceDetails[]>
    reload: () => void,
    reloadHouse: (id: number) => void
}

const StorageContext = React.createContext<Storage | undefined>(undefined);
export {StorageContext};

function useStorage() {
    const storage = useContext(StorageContext)

    return storage
}

export {useStorage}

function CompanyAdminIndexPage(props: Props) {
    const auth = useAuth()
    const [comapny, setCompany] = useState<ConstructionCompanyDetails>()
    const [loading, setLoading] = useState(true)
    const [entances, setEntrances] = useState<Record<number, HouseEntranceDetails[]>>({})
    const [searches, SetSearches] = useState<Record<number, string>>({})
    
    const Outlet = useOutlet()
    const location = useLocation();
    
    useEffect(() => {
        ConstructionCompanyService.getApiConstructioncompany().then(d => setCompany(d)).finally(() => setLoading(false))
    }, [])

    const load = (house: ApartmentHouseDetails) => {
        if (house.id) ConstructionCompanyService.getApiConstructioncompanyHouses(house.id, searches[house.id]).then(d => {
            let newEntances = JSON.parse(JSON.stringify(entances)) as Record<number, HouseEntranceDetails[]>
            newEntances[house.id!] = d
            setEntrances(newEntances)
        })
    }

    const searchChange = (e: ChangeEvent<HTMLInputElement>, house: ApartmentHouseDetails) => {
        let newSearches = JSON.parse(JSON.stringify(searches)) as Record<number, string>
        newSearches[house.id!] = e.target.value
        SetSearches(newSearches)
    }

    const reload = () => {
        setLoading(true)
        ConstructionCompanyService.getApiConstructioncompany().then(d => setCompany(d)).finally(() => setLoading(false))
    }
    
    const reloadHouse = (id: number) => {
        load({id})
    }

    return <StorageContext.Provider value={{comapny, entances, reload, reloadHouse}}>
        <motion.div className="adminPanel" variants={upVariants} initial={'init'} animate={'show'} exit={'hide'}>
            <h1>Админ-Панель</h1>
            <ul className="JK_container">
                <Container>
                <Row>
                <Col>
                {comapny?.residentialComplexes?.map(c => <li key={c.id}>
                    <p className="JK_name">ЖК {c.name}</p>
                    <button className="deleteJK" onClick={() => {
                        ConstructionCompanyService
                            .deleteApiConstructioncompanyComplexes(c.id!)
                            .then(() => reload())
                    }}>Удалить</button>
                    <ul>
                        {c.apartmentHouses?.map(h => <li key={h.id}>
                            Дом {addressToString(h.address)}
                            <button onClick={() => {
                                ConstructionCompanyService
                                    .deleteApiConstructioncompanyHouses(h.id!)
                                    .then(() => reload())
                            }}>Удалить</button>
                            <br/>
                            <input value={searches[h.id!] || ''} onChange={e => searchChange(e, h)}
                                   placeholder={"Номер квартиры"}/>
                            <button onClick={() => load(h)}>Загрузить квартиры</button>
                            <ul>
                                {h.id! in entances && entances[h.id!].map(e => <li key={e.id}>
                                    Подъезд {e.enranceNumber}
                                    <button onClick={() => {
                                        ConstructionCompanyService
                                            .deleteApiConstructioncompanyEntrances(e.id!)
                                            .then(() => reloadHouse(h.id!))
                                    }}>Удалить</button>
                                    <ul>
                                        {e.apartments?.map(a => <li key={a.id}>
                                            <Link to={`details/apartment/${a.id}`}>Квартира №{a.apartmentNumber}</Link>
                                            <button onClick={() => {
                                                ConstructionCompanyService
                                                    .deleteApiConstructioncompanyApartments(a.id!)
                                                    .then(() => reloadHouse(h.id!))
                                            }}>Удалить</button>
                                            <br/>
                                            Коды приглашений:
                                            <ul>
                                                {a.inviteCodes?.map(i => <li>
                                                    {i.code} <button onClick={() => {
                                                    ConstructionCompanyService.deleteApiConstructioncompanyCodes(i.id!).then(() => {
                                                        reloadHouse(h.id!)
                                                    })
                                                }}>Удалить</button>
                                                </li>)}
                                            </ul>
                                            <button onClick={() => {
                                                ConstructionCompanyService.postApiConstructioncompanyCodes(a.id!).then(() => {
                                                    reloadHouse(h.id!)
                                                })
                                            }}>Добавить код</button>
                                            <br/>
                                            Умный дом:
                                            <ul>
                                                {a.smartHomeDevices?.map(d => <li>
                                                    {d.smartHomeDeviceType == SmartHomeDeviceType.INTERCOM && "Домофон"}  <button onClick={() => {
                                                    ConstructionCompanyService.deleteApiConstructioncompanyDevices(d.id!).then(() => {
                                                        reloadHouse(h.id!)
                                                    })
                                                }}>Удалить</button>
                                                </li>)}
                                            </ul>
                                            <button onClick={() => {
                                                ConstructionCompanyService.postApiConstructioncompanyApartmentsDevices(a.id!, {smartHomeDeviceType: SmartHomeDeviceType.INTERCOM}).then(() => {
                                                    reloadHouse(h.id!)
                                                })
                                            }}>Добавить домофон</button>
                                        </li>)}
                                    </ul>
                                    <Link className="add_area_btn a" to={`create/apartment/${h.id}/${e.id}`}>Создать квартиру</Link>
                                </li>)}
                            </ul>
                            <Link className="add_area_btn b" to={`create/entrance/${h.id}`}>Создать подъезд</Link>
                        </li>)}
                    </ul>
                    <Link className="add_area_btn c" to={`create/house/${c.id}`}>Создать дом</Link>
                </li>)}
                </Col>

                <Col className="apartament_info">
                    <AnimatePresence exitBeforeEnter>
                        {Outlet && React.cloneElement(Outlet, {key: location.pathname})}
                    </AnimatePresence>
                </Col>

                </Row>
                </Container>
            </ul>
            <Link className="createNewComplex" to={'create/complex'}>+</Link> <br/>
            {/*<Link to={''}>Назад</Link>*/}
            <br/>
        </motion.div>
    </StorageContext.Provider>
}

export default CompanyAdminIndexPage;