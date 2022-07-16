import {useAuth} from "../components/AuthProvider";
import {useEffect, useState} from "react";
import {upVariants} from "../animations";
import {motion} from "framer-motion";
import {
    ApartmentViewModel,
    SmartHomeDevice, SmartHomeDeviceDTO,
    SmartHomeDevicesService,
    SmartHomeDeviceType,
    TenantAppartamentsService
} from "../api";
import {apartamentToAddressSting} from "../addressToString";

import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Carousel from 'react-bootstrap/Carousel';
import Dropdown from 'react-bootstrap/Dropdown';
import '../styles/IndexPage.scss';
import profileImage from '../images/profileImage.svg';
import lampImage from '../images/lampImage.svg';

function TenantIndexPage() {
    const auth = useAuth()
    
    const [apartmentsLoading, setApartmentsLoading] = useState(true)
    const [apartments, setApartments] = useState<ApartmentViewModel[]>([])
    const [selectedAparment, setSelectedAparment] = useState<ApartmentViewModel>()
    
    const [smartHomeDevices, setSmartHomeDevices] = useState<SmartHomeDeviceDTO[]>()
    const [smartHomeDevicesLoadng, setSmartHomeDevicesLoadng] = useState(false)
    
    useEffect(() => {
        TenantAppartamentsService.getApiTenantappartaments().then(d => setApartments(d)).finally(() => setApartmentsLoading(false))
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

        <h3 className="text_blue_style smartHome"><b>Умный дом</b></h3>
        <Container>
            <Row>
            {smartHomeDevices?.map(d => <>
                {d.actions?.map(a => <button className="smart_element" onClick={() => {
                    SmartHomeDevicesService.postApiSmarthomedevicesUse(d.id!, a.actionId!)
                }}><img className="lampImage" src={lampImage}/>{a.name}</button>

                )}
                </>
            )}

            </Row>
        </Container>

        <h3 className="text_blue_style smartHome"><b>Услуги</b></h3>

        <Container>
            <Row>
                <Col>

                    <Dropdown className="flatServices">
                      <Dropdown.Toggle variant="success" id="dropdown-basic" className="dropdown_toggle flat_services">
                        <span className="filters_text">Услуги для квартиры</span>
                      </Dropdown.Toggle>

                      <Dropdown.Menu className="dropdown_menu">
                        <Dropdown.Item href="#/action-1">Юр. услуги</Dropdown.Item>
                        <Dropdown.Item href="#/action-1">Страхование</Dropdown.Item>
                      </Dropdown.Menu>
                    </Dropdown>

                </Col>

                <Col>

                    <Dropdown className="otherServices">
                      <Dropdown.Toggle variant="success" id="dropdown-basic" className="dropdown_toggle other_services">
                        <span className="filters_text">Доп Услуги</span>
                      </Dropdown.Toggle>

                      <Dropdown.Menu className="dropdown_menu">
                        <Dropdown.Item href="#/action-1">Уход за животными</Dropdown.Item>
                        <Dropdown.Item href="#/action-1">Уборка</Dropdown.Item>
                      </Dropdown.Menu>
                    </Dropdown>

                </Col>
            </Row>
        </Container>
    </motion.div>
}

export default TenantIndexPage;