import {useAuth} from "../components/AuthProvider";
import React, {ChangeEvent, useContext, useEffect, useState} from "react";
import {
    ApartmentHouseDetails, ApplicationUser,
    ConstructionCompany,
    ConstructionCompanyDetails,
    ConstructionCompanyService,
    ConstructionCompanyViewModel, HouseEntrance, HouseEntranceDetails
} from "../api";
import {upVariants} from "../animations";
import {AnimatePresence, motion} from "framer-motion";
import {addressToString} from "../addressToString";
import {Link, Outlet, useLocation, useOutlet} from "react-router-dom";

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
        <motion.div variants={upVariants} initial={'init'} animate={'show'} exit={'hide'} className={'layout'}>
            <h1>Админка наша любимая</h1>
            <ul>
                {comapny?.residentialComplexes?.map(c => <li key={c.id}>
                    ЖК {c.name}
                    <button onClick={() => {
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
                                            Квартира №{a.apartmentNumber}
                                            <button onClick={() => {
                                                ConstructionCompanyService
                                                    .deleteApiConstructioncompanyApartments(a.id!)
                                                    .then(() => reloadHouse(h.id!))
                                            }}>Удалить</button>
                                        </li>)}
                                    </ul>
                                    <Link to={`create/apartment/${h.id}/${e.id}`}>Создать квартиру</Link>
                                </li>)}
                            </ul>
                            <Link to={`create/entrance/${h.id}`}>Создать подъезд</Link>
                        </li>)}
                    </ul>
                    <Link to={`create/house/${c.id}`}>Создать дом</Link>
                </li>)}
            </ul>
            <Link to={'create/complex'}>Создать комплекс</Link> <br/>
            <Link to={''}>Назад</Link>
            <br/>
            <AnimatePresence exitBeforeEnter>
                {Outlet && React.cloneElement(Outlet, {key: location.pathname})}
            </AnimatePresence>
        </motion.div>
    </StorageContext.Provider>
}

export default CompanyAdminIndexPage;