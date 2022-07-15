import {useStorage} from "./CompanyAdminIndexPage";
import {useState} from "react";
import {horizontalVariants, upVariants} from "../animations";
import { motion } from "framer-motion";
import {Address, ConstructionCompanyService} from "../api";
import {useParams} from "react-router-dom";

export interface Props {

}

function CreateComplexPage(props: Props) {
    const storage = useStorage()
    if (!storage) return <></>
        
    const {complex} = useParams()
    const [address, setAddress] = useState<Address>({})
    
    return  <motion.div variants={horizontalVariants} initial={'init'} animate={'show'} exit={'hide'} className={'layout'}>
        Создание дома
        <input value={address.city || ''} onChange={e => setAddress({...address, city: e.target.value})} placeholder={"Город"}/>
        <input value={address.street || ''} onChange={e => setAddress({...address, street: e.target.value})} placeholder={"Улица"}/>
        <input value={address.houseNumber || ''} onChange={e => setAddress({...address, houseNumber: parseInt(e.target.value)})} type={"number"} placeholder={"Номер дома"}/>
        <button onClick={() => {
            if (complex) ConstructionCompanyService.postApiConstructioncompanyHouses({address, residentialComplexId: parseInt(complex)}).finally(() => {
                storage?.reload()
            })
        }}>Создать</button>
    </motion.div>
}

export default CreateComplexPage;