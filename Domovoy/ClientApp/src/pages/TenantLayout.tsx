import React from "react";
import {AnimatePresence, motion} from "framer-motion";
import {Link, useOutlet, useLocation} from "react-router-dom";
import {upVariants} from "../animations";
import '../styles/menu.css';

import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import mainIcon from '../images/mainIcon.svg';
import mainActiveIcon from '../images/mainActiveIcon.svg';
import searchIcon from '../images/searchIcon.svg';
import searchActiveIcon from '../images/searchActiveIcon.svg';
import chatIcon from '../images/chatIcon.svg';
import chatActiveIcon from '../images/chatActiveIcon.svg';
import profileIcon from '../images/profileIcon.svg';
import profileActiveIcon from '../images/profileActiveIcon.svg';

export interface Props {

}

function TenantLayout(props: Props) {
    const location = useLocation()
    const Outlet = useOutlet()

    console.log(location.pathname)
    
    return <motion.div variants={upVariants} initial={'init'} animate={'show'} exit={'hide'} style={{
        width: '100%',
        minHeight: '100vh'
    }}>
        <AnimatePresence exitBeforeEnter>
            {Outlet && React.cloneElement(Outlet, {key: location.pathname})}
        </AnimatePresence>
        
        <nav>
            <Container>
                <Row>
                    <Col><Link to={''} className="nav_link"><img src={location.pathname == '/' ? mainActiveIcon : mainIcon}/></Link></Col>
                    <Col><Link to={'search'} className="nav_link"><img src={location.pathname == '/search' ? searchActiveIcon : searchIcon}/></Link></Col>
                    <Col><Link to={'chat'} className="nav_link"><img src={location.pathname == '/chat' ? chatActiveIcon : chatIcon}/></Link></Col>
                    <Col><Link to={'profile'} className="nav_link"><img src={location.pathname == '/profile' ? profileActiveIcon : profileIcon}/></Link></Col>
                </Row>
            </Container>
        </nav>

    </motion.div>
}

export default TenantLayout;