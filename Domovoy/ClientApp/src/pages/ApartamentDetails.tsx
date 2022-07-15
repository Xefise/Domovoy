import {useStorage} from "./CompanyAdminIndexPage";
import {useParams} from "react-router-dom";
import {horizontalVariants} from "../animations";
import { motion } from "framer-motion";
import {apartamentToAddressSting} from "../addressToString";
import {AparmentState, AparmentType, ApartmentViewModel, ConstructionCompanyService} from "../api";
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
                    <p>Жилая площадь: {apartmentObject.livingArea}</p>
                    <p>Площадь без балконов/лоджий: {apartmentObject.areaWithoutBalconies}</p>
                    <p>Этаж: {apartmentObject.floor}</p>
                    <p>Статус: {apartmentObject.aparmentState}</p>
                    <p>Тип: {apartmentObject.aparmentType}</p>
                </>
                : <>
                    <p>Номер квартиры: <input value={apartmentObject.apartmentNumber} type={"number"} onChange={e => setApartmentObject({...apartmentObject, apartmentNumber: parseInt(e.target.value)})}/></p>
                    <p>Площадь: <input value={apartmentObject.area} type={"number"} onChange={e => setApartmentObject({...apartmentObject, area: parseInt(e.target.value)})}/></p>
                    <p>Жилая площадь: <input value={apartmentObject.livingArea} type={"number"} onChange={e => setApartmentObject({...apartmentObject, livingArea: parseInt(e.target.value)})}/></p>
                    <p>Площадь без балконов/лоджий: <input value={apartmentObject.areaWithoutBalconies} type={"number"} onChange={e => setApartmentObject({...apartmentObject, areaWithoutBalconies: parseInt(e.target.value)})}/></p>
                    <p>Этаж: <input value={apartmentObject.floor} type={"number"} onChange={e => setApartmentObject({...apartmentObject, floor: parseInt(e.target.value)})}/></p>
                    
                    <p>Статус: <select value={apartmentObject.aparmentState} onChange={(e) => setApartmentObject({...apartmentObject, aparmentState: e.target.value as AparmentState})}>
                        <option value={AparmentState.NOT_FOR_SELL}>NOT_FOR_SELL</option>
                        <option value={AparmentState.FOR_SELL}>FOR_SELL</option>
                        <option value={AparmentState.FOR_RENT}>FOR_RENT</option>
                        <option value={AparmentState.BOOKED}>BOOKED</option>
                    </select></p>

                    <p>Статус: <select value={apartmentObject.aparmentType} onChange={(e) => setApartmentObject({...apartmentObject, aparmentType: e.target.value as AparmentType})}>
                        <option value={AparmentType.LIVING}>LIVING</option>
                        <option value={AparmentType.COMMERCIAL}>COMMERCIAL</option>
                    </select></p>
                </>
            }
        </>}
    </motion.div>
}

export default ApartamentDetails;