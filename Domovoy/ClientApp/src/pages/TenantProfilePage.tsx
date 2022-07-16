import {upVariants} from "../animations";
import {motion} from "framer-motion";
import {useAuth} from "../components/AuthProvider";
import {useEffect, useState} from "react";
import {
    ApartmentPutTenant, ApartmentState,
    ApartmentViewModel,
    TenantAppartamentsService,
    TenantCartService,
    TenantRequestsService
} from "../api";
import {apartamentToAddressSting} from "../addressToString";
import {Link, useNavigate} from "react-router-dom";

import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Carousel from 'react-bootstrap/Carousel';
import '../styles/menu.css';
import '../styles/carousel.css';
import '../styles/ProfilePage.scss';
import profileImage from '../images/profileImage.svg';
import editIcon from '../images/editIcon.svg';
import basketIcon from '../images/basketIcon.svg';
import important from '../images/important.svg';
import flat1 from '../images/flat1.svg';
import flat2 from '../images/flat2.svg';

export interface Props {

}

function TenantProfilePage(props: Props) {
    const auth = useAuth()
    const navigate = useNavigate()

    const [apartamentsLoading, setApartamentsLoading] = useState(true)
    const [apartaments, setApartaments] = useState<ApartmentViewModel[]>([])

    const [cartLoading, setCartLoading] = useState(true)
    const [cart, setCart] = useState<ApartmentViewModel[]>([])
    
    const [code, setCode] = useState("")
    
    const [editingApartment, setEditingApartment] = useState<ApartmentPutTenant>()

    useEffect(() => {
        TenantAppartamentsService.getApiTenantappartaments().then(d => setApartaments(d)).finally(() => setApartamentsLoading(false))
        TenantCartService.getApiTenantcart().then(d => setCart(d)).finally(() => setCartLoading(false))
    }, [])
    
    const removeFromCart = (id: number) => {
        setCartLoading(true)
        TenantCartService.deleteApiTenantcart(id).then(() => {
            TenantCartService.getApiTenantcart().then(d => setCart(d)).finally(() => setCartLoading(false))
        })
    }
    
    return <motion.div className="profilePage" variants={upVariants} initial={'init'} animate={'show'} exit={'hide'}>

        <Container>
            <div className="previousPage">
                <Link to={'/'} className="nav_link"><span className="back">&lt;</span> &nbsp; <b>Профиль</b></Link>
            </div>
        </Container>

        <Container className="profileBlock">
            <img src={profileImage}/>
            <img src={editIcon} className="edit_profile"/>
            {/*<p className="profile_status">Ищет квартиру</p>*/}
            <b className="text_blue_style">{auth.user?.lastName} {auth.user?.firstName}</b>
        </Container>

        <b className="text_blue_style my_flat">Мои квартиры</b>
        <Carousel indicators={false}>
            {apartaments.map(a =>
                <Carousel.Item>
                    <div className="flatBlock">
                        <Container className="myflatsList">
                            <Row>
                                {/*<Col xs={11} md={11} sm={10}><p className="flat_status">Ищет квартиру</p></Col>*/}
                                <Col xs={12} md={12} sm={12}><p className="more_info" style={{cursor: "pointer"}} onClick={() => {
                                    if (!editingApartment) setEditingApartment(a)
                                }}>Редактировать</p></Col>
                            </Row>
                            <Row>
                                {apartamentToAddressSting(a)}
                            </Row>
                            <Row>

                            </Row>
                            <Row>
                                {!editingApartment || editingApartment.id != a.id 
                                    ? <>
                                        
                                        <Container>

                                            <Row>
                                                
                                                <Col>
                                                    <img className="flat_img" src={flat1}/>
                                                </Col>

                                                <Col>
                                                    <img className="flat_img" src={flat2}/>
                                                </Col>

                                            </Row>

                                        </Container>

                                        <p>Характеристики:</p>
                                        <br/>
                                        <p>{a.area} м²</p>
                                    </>
                                    : <>
                                        Стоимость: <input value={editingApartment.cost || 0} type={"number"} onChange={e => setEditingApartment({...editingApartment, cost: parseInt(e.target.value)})}/>
                                        <p>Статус: <select value={editingApartment.apartmentState} onChange={(e) => setEditingApartment({...editingApartment, apartmentState: e.target.value as ApartmentState})}>
                                            <option value={ApartmentState.NOT_FOR_SELL}>NOT_FOR_SELL</option>
                                            <option value={ApartmentState.FOR_SELL}>FOR_SELL</option>
                                            <option value={ApartmentState.FOR_RENT}>FOR_RENT</option>
                                            <option value={ApartmentState.BOOKED}>BOOKED</option>
                                        </select></p>
                                        Описание: <input value={editingApartment.description || ''} onChange={e =>setEditingApartment({...editingApartment, description: e.target.value})}/>
                                        <button disabled={apartamentsLoading} onClick={() => {
                                            setApartamentsLoading(true)
                                            TenantAppartamentsService.putApiTenantappartaments(editingApartment.id!, editingApartment).then(() => {
                                                TenantAppartamentsService.getApiTenantappartaments().then(d => setApartaments(d)).finally(() => {
                                                    setEditingApartment(undefined)
                                                    setApartamentsLoading(false);
                                                })
                                            })
                                        }}>Сохранить</button>
                                    </>
                                }
                            </Row>
                        </Container>
                    </div>
                </Carousel.Item>
            )}
            {apartaments.length == 0 &&
                <Carousel.Item style={{height: 214}}>
                    <div className="flatBlock">
                        <Container className="myflatsList">
                            <Row>
                                <p>У вас нет квартир</p>
                            </Row>
                        </Container>
                    </div>
                </Carousel.Item>
            }
        </Carousel>
        
        <Container className={"code_input"}>
            <p>Введите код для добавления квартиры</p>
            <input value={code} onChange={e => setCode(e.target.value)}/>
            <button disabled={apartamentsLoading} onClick={() => {
                setApartamentsLoading(true)
                TenantAppartamentsService.postApiTenantappartamentsJoin(code).then(() => {
                    setApartamentsLoading(true)
                    TenantAppartamentsService.getApiTenantappartaments().then(d => setApartaments(d)).finally(() => setApartamentsLoading(false))
                }).finally(() => setApartamentsLoading(false))
            }}>Добавить</button>
        </Container>

        <b className="text_blue_style my_flat">Ваша корзина</b>
        <Carousel>
            {cart.map(a =>
                <Carousel.Item>
                    <div className="flatBlock">
                        <Container className="myflatsList">
                            <Row>
                                <Col xs={6} md={6} sm={12}><p onClick={() => {
                                    TenantRequestsService.postApiTenantrequests(a.id!, "Заказанно через корзину")
                                }} style={{cursor: "pointer"}} className="more_info">Отправить запрос</p></Col>
                                <Col xs={1} md={1} sm={1}><p onClick={() => {
                                    TenantCartService.deleteApiTenantcart(a.id!).then(() => {
                                        setCartLoading(true)
                                        TenantCartService.getApiTenantcart().then(d => setCart(d)).finally(() => setCartLoading(false))
                                    })
                                }} style={{cursor: "pointer"}} className="more_info">Удалить</p></Col>
                            </Row>
                            <Container>

                                <Row>
                                                
                                    <Col>
                                        <img className="flat_img" src={flat1}/>
                                    </Col>

                                    <Col>
                                        <img className="flat_img" src={flat2}/>
                                    </Col>

                                </Row>

                            </Container>
                            <Row>
                                {apartamentToAddressSting(a)}
                            </Row>
                            <Row>

                            </Row>
                            <Row>
                                <p>Характеристики:</p>
                                <br/>
                                <p>{a.area} м²</p>
                            </Row>
                        </Container>
                    </div>
                </Carousel.Item>
            )}
            {cart.length == 0 &&
                <Carousel.Item style={{height: 214}}>
                    <div className="flatBlock">
                        <Container className="myflatsList">
                            <Row>
                                <p>У вас нет квартир в корзине</p>
                            </Row>
                        </Container>
                    </div>
                </Carousel.Item>
            }
        </Carousel>

        <Container className="fotter_container">
            <button className="solveProblem">Решить проблему в квартире &nbsp; <img src={important}/></button>
            <button onClick={() => navigate('/logout')} style={{marginTop: 10}} className="solveProblem">Выйти</button>
        </Container>
        
        <br/>
        <br/>

        {/*Ваша корзина:
        <ul>
            {cart.map(a => <li>
                {apartamentToAddressSting(a)} <button onClick={() => removeFromCart(a.id!)}>Удалить</button>
            </li>)}
        </ul>*/}
        
    </motion.div>
}

export default TenantProfilePage;
