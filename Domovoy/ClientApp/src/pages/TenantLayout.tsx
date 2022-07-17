import React from "react";
import {AnimatePresence, motion} from "framer-motion";
import {Link, useOutlet, useLocation} from "react-router-dom";
import {navVariants, upVariants} from "../animations";
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
   
    return <>
        <motion.div variants={upVariants} initial={'init'} animate={'show'} exit={'hide'} style={{
            width: '100%',
            minHeight: '100vh'
        }}>
            <AnimatePresence exitBeforeEnter>
                {Outlet && React.cloneElement(Outlet, {key: location.pathname})}
            </AnimatePresence>
        </motion.div>
        <div className={"navWrapper"}>
            <motion.nav variants={navVariants} initial={'init'} animate={'show'} exit={'hide'}>
                <Container>
                    <Row>
                        <Col><Link to={''} className="nav_link"><img
                            src={location.pathname == '/' ? mainActiveIcon : mainIcon}/></Link></Col>
                        <Col><Link to={'search'} className="nav_link"><img
                            src={location.pathname == '/search' ? searchActiveIcon : searchIcon}/></Link></Col>
                        <Col><Link to={'chat'} className="nav_link"><img
                            src={location.pathname == '/chat' ? chatActiveIcon : chatIcon}/></Link></Col>
                        <Col><Link to={'profile'} className="nav_link"><img
                            src={location.pathname == '/profile' ? profileActiveIcon : profileIcon}/></Link></Col>
                    </Row>
                </Container>
            </motion.nav>
        </div>
    </>
}

export default TenantLayout;