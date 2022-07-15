import {useStorage} from "./CompanyAdminIndexPage";
import {useState} from "react";
import {horizontalVariants, upVariants} from "../animations";
import { motion } from "framer-motion";
import {Address, ConstructionCompanyService} from "../api";
import {useParams} from "react-router-dom";

export interface Props {

}

function CreateApartmentPage(props: Props) {
    const storage = useStorage()
    if (!storage) return <></>
        
    const {house, entrance} = useParams()
    const [apartmentNumber, setNumber] = useState(1)
    const [area, setArea] = useState(1)
    const [floor, setFloor] = useState(1)
    const [isSelling, setIsSelling] = useState(false)
    
    return  <motion.div variants={horizontalVariants} initial={'init'} animate={'show'} exit={'hide'} className={'layout'}>
        Создание квартиры
        <input value={apartmentNumber} onChange={e => setNumber(parseInt(e.target.value))} type={"number"} placeholder={"Номер квартиры"}/>
        <input value={area} onChange={e => setArea(parseInt(e.target.value))} type={"number"} placeholder={"Площадь"}/>
        <input value={floor} onChange={e => setFloor(parseInt(e.target.value))} type={"number"} placeholder={"Этаж"}/>
        <input checked={isSelling} type={"checkbox"} onChange={e => setIsSelling(e.target.checked)} placeholder={"Продаётся"}/>
        <button onClick={() => {
            if (house && entrance) ConstructionCompanyService.postApiConstructioncompanyApartments({area, floor, apartmentNumber, isSelling, houseEntranceId: parseInt(entrance)}).finally(() => {
                storage?.reloadHouse(parseInt(house))
            })
        }}>Создать</button>
    </motion.div>
}

export default CreateApartmentPage;