import React from "react";
import {AnimatePresence, motion} from "framer-motion";
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
import {navVariants, upVariants} from "../animations";

export interface Props {

}

function CompanyAdminLayout(props: Props) {
    const Outlet = useOutlet()

    return <>
        <motion.div variants={upVariants} initial={'init'} animate={'show'} exit={'hide'} style={{
            width: '100%',
            minHeight: '100vh'
        }}>
            <AnimatePresence exitBeforeEnter>
                {Outlet && React.cloneElement(Outlet, {key: location.pathname.split("create")[0].split("details")[0]})}
            </AnimatePresence>
        </motion.div>
        <div className={"navWrapper"}>
            <motion.nav variants={navVariants} initial={'init'} animate={'show'} exit={'hide'}>
                <Container>
                    <Row>
                        <Col><Link to={''} className="nav_link"><img
                            src={location.pathname == '/' ? mainActiveIcon : mainIcon}/></Link></Col>
                        <Col><Link to={'logout'} className="nav_link">Выход</Link></Col>
                    </Row>
                </Container>
            </motion.nav>
        </div>
    </>

}

export default CompanyAdminLayout;