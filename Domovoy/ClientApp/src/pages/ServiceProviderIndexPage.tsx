import React, {useEffect, useState} from "react";
import {
    ApartmentServiceType,
    InformerServiceType,
    ServiceEntriesCollection,
    ServiceProvidersService,
    ServiceType
} from "../api";
import {upVariants} from "../animations";
import {motion} from "framer-motion";
import {apartamentToAddressSting} from "../addressToString";

export interface Props {

}

function ServiceProviderIndexPage(props: Props) {
    const [requests, setRequests] = useState<ServiceEntriesCollection>()
    const [loading, setLoading] = useState(true)

    const load = () => {
        setLoading(true)
        ServiceProvidersService.getApiServiceprovidersEntries().then(d => setRequests(d)).finally(() => setLoading(false))
    }

    useEffect(() => load(), [])

    return <motion.div variants={upVariants} initial={'init'} animate={'show'} exit={'hide'}>
        <h3>Запросы</h3>
        <ul>
            {requests?.apartmentServicesEntries?.map(s => <li>
                Название услуги: {s.service?.name} <br/>
                Тип услуги:
                {s.service?.type == ApartmentServiceType.ANIMALS && " Уход за животными"}
                {s.service?.type == ApartmentServiceType.CLEANING && " Уборка"}
                <br/>
                Квартира: {apartamentToAddressSting(s.apartment || {})} <br/>
                Заказчик: {s.user?.firstName} {s.user?.lastName} {s.user?.email} <br/>
                Данные: {s.data} <br/>
                Статус: {s.completed ? "Выполнено" : "Не выполнено"} <br/>
                {!s.completed && <button onClick={() => {
                    setLoading(true)
                    ServiceProvidersService.getApiServiceprovidersComplete(s.id!, ServiceType.APARTMENT).then(load)
                }}>Выполнено</button>}
                <br/>
            </li>)}
            {requests?.informerServicesEntries?.map(s => <li>
                Название услуги: {s.service?.name} <br/>
                Тип услуги:
                {s.service?.type == InformerServiceType.WATER && " Показания воды"}
                <br/>
                Квартира: {apartamentToAddressSting(s.apartment || {})} <br/>
                Заказчик: {s.user?.firstName} {s.user?.lastName} {s.user?.email} <br/>
                Данные: {s.data} <br/>
                Статус: {s.completed ? "Выполнено" : "Не выполнено"} <br/>
                {!s.completed && <button onClick={() => {
                    setLoading(true)
                    ServiceProvidersService.getApiServiceprovidersComplete(s.id!, ServiceType.INFRORMER).then(load)
                }}>Выполнено</button>}
                <br/>
            </li>)}
            {requests?.userServicesEntries?.map(s => <li>
                Название услуги: {s.service?.name} <br/>
                <br/>
                Заказчик: {s.user?.firstName} {s.user?.lastName} {s.user?.email}<br/>
                Данные: {s.data} <br/>
                Статус: {s.completed ? "Выполнено" : "Не выполнено"} <br/>
                {!s.completed && <button onClick={() => {
                    setLoading(true)
                    ServiceProvidersService.getApiServiceprovidersComplete(s.id!, ServiceType.USER).then(load)
                }}>Выполнено</button>}
                <br/>
            </li>)}
        </ul>
    </motion.div>
}

export default ServiceProviderIndexPage;