import React from "react";
import {AnimatePresence} from "framer-motion";
import {Link, useOutlet} from "react-router-dom";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import mainActiveIcon from "../images/mainActiveIcon.svg";
import mainIcon from "../images/mainIcon.svg";
import searchActiveIcon from "../images/searchActiveIcon.svg";
import searchIcon from "../images/searchIcon.svg";
import chatActiveIcon from "../images/chatActiveIcon.svg";
import chatIcon from "../images/chatIcon.svg";
import profileActiveIcon from "../images/profileActiveIcon.svg";
import profileIcon from "../images/profileIcon.svg";
import Container from "react-bootstrap/Container";

export interface Props {

}

function CompanyAdminLayout(props: Props) {
    const Outlet = useOutlet()
    
    return <>
        <AnimatePresence exitBeforeEnter>
            {Outlet && React.cloneElement(Outlet, {key: location.pathname.split("create")[0].split("details")[0]})}
        </AnimatePresence>
        
        <nav>
            <Container>
                <Row>
                    <Col><Link to={''} className="nav_link"><img src={location.pathname == '/' ? mainActiveIcon : mainIcon}/></Link></Col>
                    <Col><Link to={'logout'} className="nav_link">Выход</Link></Col>
                </Row>
            </Container>
        </nav>
    </>
}

export default CompanyAdminLayout;