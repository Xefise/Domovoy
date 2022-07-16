import {useAuth} from "../components/AuthProvider";
import React, {ChangeEvent, useContext, useEffect, useState} from "react";
import {
    AgentRequestsService,
    ApartmentHouseDetails, ApartmentRequestDTO,
    ConstructionCompanyDetails,
    ConstructionCompanyService,
    HouseEntranceDetails,
    SmartHomeDeviceType
} from "../api";
import {upVariants} from "../animations";
import {AnimatePresence, motion} from "framer-motion";
import {addressToString, apartamentToAddressSting} from "../addressToString";
import {Link, useLocation, useOutlet} from "react-router-dom";

export interface Props {

}

function CompanyAdminIndexPage(props: Props) {
    const [requests, setRequests] = useState<ApartmentRequestDTO[]>()
    const [loading, setLoading] = useState(true)

    const load = () => {
        setLoading(true)
        AgentRequestsService.getApiAgentrequests().then(d => setRequests(d)).finally(() => setLoading(false))
    }

    useEffect(() => load(), [])

    return <>
        <h3>Запросы</h3>
        <ul>
            {requests?.map(r => <li>
                {r.requester?.firstName} {r.requester?.lastName} {r.requester?.patronymic} Запросил {apartamentToAddressSting(r.apartment || {})} <br/>
                Инфо о помещении:
                <p>Площадь: {r.apartment?.area}</p>
                <p>Жилая площадь: {r.apartment?.livingArea}</p>
                <p>Площадь без балконов/лоджий: {r.apartment?.areaWithoutBalconies}</p>
                <p>Этаж: {r.apartment?.floor}</p>
                <p>Статус: {r.apartment?.apartmentState}</p>
                <p>Тип: {r.apartment?.apartmentType}</p>
                <p>Стоимость: {r.apartment?.cost}</p>
                <button onClick={() => {
                    AgentRequestsService.postApiAgentrequestsAccept(r.id!).then(load)
                }}>Принять</button>
                <button onClick={() => {
                    AgentRequestsService.postApiAgentrequestsDeny(r.id!).then(load)
                }}>Отклонить</button>
            </li>)}
        </ul>
    </>
}

export default CompanyAdminIndexPage;