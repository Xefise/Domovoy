import {useAuth} from "../components/AuthProvider";
import {useEffect, useState} from "react";
import {upVariants} from "../animations";
import {motion} from "framer-motion";
import {
    ApartmentViewModel,
    SmartHomeDevice, SmartHomeDeviceDTO,
    SmartHomeDevicesService,
    SmartHomeDeviceType,
    TenantAppartamentsService, TenantCartService, TenantRecomendationsService
} from "../api";
import {apartamentToAddressSting} from "../addressToString";

import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Carousel from 'react-bootstrap/Carousel';
import Dropdown from 'react-bootstrap/Dropdown';
import '../styles/IndexPage.scss';
import profileImage from '../images/profileImage.svg';
import houseImg from '../images/houseImg.svg';
import flat3 from '../images/flat3.svg';
import flat4 from '../images/flat4.svg';
import flat5 from '../images/flat5.svg';
import advert_img1 from '../images/advert_img1.png';
import advert_img2 from '../images/advert_img2.png';
import {Spinner} from "react-bootstrap";

function TenantIndexPage() {
    const auth = useAuth()
    
    const [apartmentsLoading, setApartmentsLoading] = useState(true)
    const [apartments, setApartments] = useState<ApartmentViewModel[]>([])
    const [selectedAparment, setSelectedAparment] = useState<ApartmentViewModel>()
    
    const [smartHomeDevices, setSmartHomeDevices] = useState<SmartHomeDeviceDTO[]>()
    const [smartHomeDevicesLoadng, setSmartHomeDevicesLoadng] = useState(false)
    
    const [recomendations, setRecomendations] = useState<ApartmentViewModel[]>([])
    const [recomendationsLoadng, setRecomendationsLoadng] = useState(false)
    
    useEffect(() => {
        TenantAppartamentsService.getApiTenantappartaments().then(d => setApartments(d)).finally(() => setApartmentsLoading(false))
        TenantRecomendationsService.getApiTenantrecomendations().then(d => setRecomendations(d)).finally(() => setRecomendationsLoadng(false))
    }, [])
    
    useEffect(() => {
        if (apartments.length > 0 && !selectedAparment) setSelectedAparment(apartments[0])
    }, [apartments])
    
    useEffect(() => {
        if (selectedAparment) {
            setSmartHomeDevicesLoadng(true)
            SmartHomeDevicesService.getApiSmarthomedevicesApartment(selectedAparment.id!).then(d => setSmartHomeDevices(d)).finally(() => setSmartHomeDevicesLoadng(false))
        }
    }, [selectedAparment])
    
    return <motion.div className="indexPage" variants={upVariants} initial={'init'} animate={'show'} exit={'hide'}>
        <Container className="upper_container">
            <Row>
                <Col xs={9} md={9} sm={9}>
                    <h1 className="text_blue_style"><b>Привет, {auth.user?.userName}!</b></h1> <br/>
                    <p className="welcome">Добро пожаловать в  ДОМовой</p>
                </Col>
                <Col xs={3} md={3} sm={3}>
                    <img className="profileImage" src={profileImage}/>
                </Col>
            </Row>
        </Container>
        <Container className="choose_flat">
        Выбранная квартира <br/><select value={selectedAparment?.id} onChange={e => setSelectedAparment(apartments.find(a => a.id == parseInt(e.target.value)))}>
            {apartments.map(a => <option value={a.id}>
                {apartamentToAddressSting(a)}
            </option>)}
        </select>
        </Container>

        <Container className="advert advert1">
            <Row>
                <Col xs={2}>
                    <img className="advert_img" src={advert_img1}/>
                </Col>
                <Col xs={10}>
                    <h4>Дорогой житель!</h4>
                    <p>В ближайшее время вам предстоит оплатить счета за свет, воду</p>
                </Col>
            </Row>
        </Container>

        <h3 className="text_blue_style titles"><b>Умный дом</b></h3>
        <Container>
            <Row>
                {smartHomeDevicesLoadng && <div style={{height: 190}}/> }
                {smartHomeDevices?.map(d => <>
                        {d.actions?.map(a => <motion.button initial={{opacity: 0}} animate={{opacity: 1}} className="smart_element" onClick={() => {
                                SmartHomeDevicesService.postApiSmarthomedevicesUse(d.id!, a.actionId!)
                            }}><img className="houseImg" src={houseImg}/>{a.name}</motion.button>
                        )}
                    </>
                )}
            </Row>
        </Container>

        <h3 className="text_blue_style titles"><b>Услуги</b></h3>

        <Container>
            <Row>
                <Col>

                    <Dropdown className="flatServices">
                      <Dropdown.Toggle variant="success" id="dropdown-basic" className="dropdown_toggle flat_services">
                        <span className="filters_text">Услуги для квартиры</span>
                      </Dropdown.Toggle>

                      <Dropdown.Menu className="dropdown_menu">
                        <Dropdown.Item href="#">Юр. услуги</Dropdown.Item>
                        <Dropdown.Item href="#">Страхование</Dropdown.Item>
                      </Dropdown.Menu>
                    </Dropdown>

                </Col>

                <Col>

                    <Dropdown className="otherServices">
                      <Dropdown.Toggle variant="success" id="dropdown-basic" className="dropdown_toggle other_services">
                        <span className="filters_text">Доп Услуги</span>
                      </Dropdown.Toggle>

                      <Dropdown.Menu className="dropdown_menu">
                        <Dropdown.Item href="#">Уход за животными</Dropdown.Item>
                        <Dropdown.Item href="#">Уборка</Dropdown.Item>
                      </Dropdown.Menu>
                    </Dropdown>

                </Col>

                <Col>

                    <Dropdown className="GKHServices">
                      <Dropdown.Toggle variant="success" id="dropdown-basic" className="dropdown_toggle gkh_services">
                        <span className="filters_text">ЖКХ</span>
                      </Dropdown.Toggle>

                      <Dropdown.Menu className="dropdown_menu">
                        <Dropdown.Item href="#">Оплатить комуналку</Dropdown.Item>
                      </Dropdown.Menu>
                    </Dropdown>

                </Col>

            </Row>
        </Container>

        <Container className="advert advert2">
            <Row>
                <Col xs={2}>
                    <img className="advert_img" src={advert_img2}/>
                </Col>
                <Col xs={10}>
                    <h4>Время убираться!</h4>
                    <p>В среду ожидается уборка</p>
                </Col>
            </Row>
        </Container>

        <h3 className="text_blue_style titles"><b>Рекомендации</b></h3>
        <Container className="last_item">
            <Row>
                {recomendations.map(r => <Col xs={3} md={6} sm={12} className="recommendation_element">
                    <img src={flat3}/>
                    <b>ЖК «{r.houseEntrance?.apartmentHouse?.residentialComplex?.name}»</b>
                    <p>{apartamentToAddressSting(r)}</p>
                    <p>{r.cost} ₽</p>
                    <p style={{cursor: "pointer"}} onClick={() => TenantCartService.postApiTenantcart(r.id!)}>Добавить в корзину</p>
                </Col>)}
            </Row>
        </Container>

    </motion.div>
}

export default TenantIndexPage;