import {useStorage} from "./CompanyAdminIndexPage";
import {useState} from "react";
import {horizontalVariants, upVariants} from "../animations";
import { motion } from "framer-motion";
import {Address, ConstructionCompanyService} from "../api";
import {useParams} from "react-router-dom";

export interface Props {

}

function CreateEntrancePage(props: Props) {
    const storage = useStorage()
    if (!storage) return <></>
        
    const {house} = useParams()
    const [enranceNumber, setNumber] = useState(1)
    
    return  <motion.div variants={horizontalVariants} initial={'init'} animate={'show'} exit={'hide'} className={'layout'}>
        Создание подъезда
        <input value={enranceNumber} onChange={e => setNumber(parseInt(e.target.value))} type={"number"} placeholder={"Номер подъезда"}/>
        <button onClick={() => {
            if (house) ConstructionCompanyService.postApiConstructioncompanyEntrances({enranceNumber, apartmentHouseId: parseInt(house)}).finally(() => {
                storage?.reloadHouse(parseInt(house))
            })
        }}>Создать</button>
    </motion.div>
}

export default CreateEntrancePage;