import {upVariants} from "../animations";
import {motion} from "framer-motion";
import {useAuth} from "../components/AuthProvider";
import {useEffect, useState} from "react";
import {ApartmentViewModel, TenantAppartamentsService, TenantCartService} from "../api";
import {apartamentToAddressSting} from "../addressToString";
import {Link} from "react-router-dom";

import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Carousel from 'react-bootstrap/Carousel';
import '../styles/menu.css';
import '../styles/ProfilePage.scss';
import profileImage from '../images/profileImage.svg';
import editIcon from '../images/editIcon.svg';
import basketIcon from '../images/basketIcon.svg';
import important from '../images/important.svg';

export interface Props {

}

function TenantProfilePage(props: Props) {
    const auth = useAuth()

    const [apartamentsLoading, setApartamentsLoading] = useState(true)
    const [apartaments, setApartaments] = useState<ApartmentViewModel[]>([])

    const [cartLoading, setCartLoading] = useState(true)
    const [cart, setCart] = useState<ApartmentViewModel[]>([])

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
            <p className="profile_status">Ищет квартиру</p>
            <b className="text_blue_style">{auth.user?.lastName} {auth.user?.firstName}</b>
        </Container>

        <b className="text_blue_style my_flat">Мои квартиры</b>
        <Carousel>
        {apartaments.map(a =>
      <Carousel.Item>
        <div className="flatBlock">
            <Container className="myflatsList">
                <Row>
                    <Col xs={11} md={11} sm={10}><p className="flat_status">Ищет квартиру</p></Col>
                    <Col xs={1} md={1} sm={1}><p className="more_info">...</p></Col>
                </Row>
                <Row>
                    {apartamentToAddressSting(a)}
                </Row>
                <Row>

                </Row>
                <Row>
                    <p>Характеристики:</p>
                    <br/>
                    <p>40 м²</p>
                </Row>
            </Container>
        </div>
        </Carousel.Item>
        )}
        </Carousel>

        <Container className="fotter_container">
            <img src={basketIcon} className="busket"/>
            <button className="solveProblem">Решить проблему в квартире &nbsp; <img src={important}/></button>
        </Container>

        {/*Ваша корзина:
        <ul>
            {cart.map(a => <li>
                {apartamentToAddressSting(a)} <button onClick={() => removeFromCart(a.id!)}>Удалить</button>
            </li>)}
        </ul>*/}
        
    </motion.div>
}

export default TenantProfilePage;