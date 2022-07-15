import React from "react";
import {AnimatePresence, motion} from "framer-motion";
import {Link, useOutlet} from "react-router-dom";
import {upVariants} from "../animations";
import '../styles/menu.css';

import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import mainIcon from '../images/mainIcon.svg';
import searchIcon from '../images/searchIcon.svg';
import chatIcon from '../images/chatIcon.svg';
import profileIcon from '../images/profileIcon.svg';

export interface Props {

}

function TenantLayout(props: Props) {
    const Outlet = useOutlet()
    
    return <motion.div variants={upVariants} initial={'init'} animate={'show'} exit={'hide'}>
        <AnimatePresence exitBeforeEnter>
            {Outlet && React.cloneElement(Outlet, {key: location.pathname})}
        </AnimatePresence>
        
        <nav>
            <Container>
                <Row>
                    <Col><Link to={''} className="nav_link"><img src={mainIcon}/></Link></Col>
                    <Col><Link to={'search'} className="nav_link"><img src={searchIcon}/></Link></Col>
                    <Col><Link to={'chat'} className="nav_link"><img src={chatIcon}/></Link></Col>
                    <Col><Link to={'profile'} className="nav_link"><img src={profileIcon}/></Link></Col>
                </Row>
            </Container>
        </nav>

    </motion.div>
}

export default TenantLayout;