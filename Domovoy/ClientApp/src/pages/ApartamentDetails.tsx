import {useStorage} from "./CompanyAdminIndexPage";
import {useParams} from "react-router-dom";
import {horizontalVariants} from "../animations";
import { motion } from "framer-motion";
import {apartamentToAddressSting} from "../addressToString";
import {ApartmentViewModel, ConstructionCompanyService} from "../api";
import {useEffect, useState} from "react";

export interface Props {

}

function ApartamentDetails(props: Props) {
    const storage = useStorage()
    const {apartment} = useParams()
    if (!storage || !apartment) return <></>

    const [apartmentObject, setApartmentObject] = useState<ApartmentViewModel>()
    const [laoding, setLoading] = useState(true)
    const [isEditing, setIsEdinting] = useState(false)
    
    useEffect(() => {
        ConstructionCompanyService.getApiConstructioncompanyApartments(parseInt(apartment))
            .then(d => setApartmentObject(d))
            .finally(() => setLoading(true))
    }, [])
    
    const save = () => {
        setLoading(true)
        ConstructionCompanyService.putApiConstructioncompanyApartments(parseInt(apartment), apartmentObject)
            .then(() => setIsEdinting(false))
            .finally(() => {
                if (apartmentObject?.houseEntrance?.apartmentHouse?.id) storage.reloadHouse(apartmentObject?.houseEntrance?.apartmentHouse?.id)
                setLoading(false)
            })
    }
    
    return <motion.div variants={horizontalVariants} initial={'init'} animate={'show'} exit={'hide'} className={'layout'}>
        {apartmentObject && <>
            <h3>Детали о {apartamentToAddressSting(apartmentObject)}</h3>
            {!isEditing && <button onClick={() => setIsEdinting(true)}>Редактировать</button>}
            {isEditing && <button onClick={save}>Сохранить</button>}
            {!isEditing 
                ? <>
                    <p>Площадь: {apartmentObject.area}</p>
                    <p>Этаж: {apartmentObject.floor}</p>
                    <p>Статус: {apartmentObject.aparmentState}</p>
                </>
                : <>
                    <p>Номер квартиры: <input value={apartmentObject.apartmentNumber} type={"number"} onChange={e => setApartmentObject({...apartmentObject, apartmentNumber: parseInt(e.target.value)})}/></p>
                    <p>Площадь: <input value={apartmentObject.area} type={"number"} onChange={e => setApartmentObject({...apartmentObject, area: parseInt(e.target.value)})}/></p>
                    <p>Этаж: <input value={apartmentObject.floor} type={"number"} onChange={e => setApartmentObject({...apartmentObject, floor: parseInt(e.target.value)})}/></p>
                </>
            }
        </>}
    </motion.div>
}

export default ApartamentDetails;