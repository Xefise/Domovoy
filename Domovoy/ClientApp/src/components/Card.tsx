import {motion} from "framer-motion";
import {apartamentToAddressSting} from "../addressToString";
import {ApartmentViewModel, ApartmentState} from "../api";
import {useEffect, useState} from "react";
import {cardVariants} from "../animations";

import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import flat1 from '../images/flat1.svg';
import flat2 from '../images/flat2.svg';

export interface Props {
    apartment: ApartmentViewModel
    drag: boolean,
    onSnap: (direction: "left" | "right") => void
}

function Card(props: Props) {
    const [direction, setDirection] = useState<"left" | "right">()
    
    useEffect(() => {
        if(direction) props.onSnap(direction)
    }, [direction])
    
    return <motion.div variants={cardVariants} initial={'init'} animate={'show'} exit={'hide'} onDrag={(event, info) => {
        if (info.offset.x < -150) setDirection("left")
        if (info.offset.x > 150) setDirection("right")

    }} dragSnapToOrigin={!direction} drag={props.drag && !direction} className={"card"}>
        <p className={"apartmentState"}>
            {props.apartment.apartmentState == ApartmentState.FOR_SELL && "Продается"}
            {props.apartment.apartmentState == ApartmentState.FOR_RENT && "Сдается"}
        </p>
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
        <p className={"apartment"}>{apartamentToAddressSting(props.apartment)}</p>
        <p className={"cost"}>{props.apartment.cost} ₽</p>
        <p className={""}>Этаж: {props.apartment.floor}</p>
        <p className={""}>Площадь: {props.apartment.area} кв.м.</p>
        <p className={""}>ЖК {props.apartment.houseEntrance?.apartmentHouse?.residentialComplex?.name}</p>
        <p className={""}>Застройщик {props.apartment.houseEntrance?.apartmentHouse?.residentialComplex?.constructionCompany?.name}</p>
    </motion.div>
}

export default Card;