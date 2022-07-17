import React from "react";
import {useState} from "react";
import {AnimatePresence, motion} from "framer-motion";
import {upVariants} from "../animations";
import {Link, useNavigate} from "react-router-dom";

import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

import '../styles/menu.css';
import '../styles/ApartamentPage.scss';

import add_to_busket from '../images/add_to_busket.svg';

export interface Props {

}

function ApartamentPage(props: Props) {
    
    return <motion.div className="ApartamentPage layout" variants={upVariants} initial={'init'} animate={'show'} exit={'hide'}>

        <div className="apartament_photo">
            
            <Container className="previousPage">
                <Link to={'/'} className="nav_link"><span className="back">&lt;</span> &nbsp; <b>Квартира</b></Link>
            </Container>

            <img src={add_to_busket}/>

        </div>

        <div>
            
        </div>

    </motion.div>
}

export default ApartamentPage;