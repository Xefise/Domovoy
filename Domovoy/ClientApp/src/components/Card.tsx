import {motion} from "framer-motion";
import {apartamentToAddressSting} from "../addressToString";
import {ApartmentViewModel} from "../api";
import {useEffect, useState} from "react";
import {cardVariants} from "../animations";

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
        {apartamentToAddressSting(props.apartment)}
    </motion.div>
}

export default Card;