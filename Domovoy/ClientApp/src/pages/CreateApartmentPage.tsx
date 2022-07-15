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
    
    return  <motion.div variants={horizontalVariants} initial={'init'} animate={'show'} exit={'hide'}>
        Создание квартиры
        <input value={apartmentNumber} onChange={e => setNumber(parseInt(e.target.value))} type={"number"} placeholder={"Номер квартиры"}/>
        <button onClick={() => {
            if (house && entrance) ConstructionCompanyService.postApiConstructioncompanyApartments({apartmentNumber, houseEntranceId: parseInt(entrance)}).finally(() => {
                storage?.reloadHouse(parseInt(house))
            })
        }}>Создать</button>
    </motion.div>
}

export default CreateApartmentPage;