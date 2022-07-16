import {useAuth} from "../components/AuthProvider";
import {useEffect, useState} from "react";
import {upVariants} from "../animations";
import {motion} from "framer-motion";
import {
    ApartmentViewModel,
    SmartHomeDevice, SmartHomeDeviceDTO,
    SmartHomeDevicesService,
    SmartHomeDeviceType,
    TenantAppartamentsService
} from "../api";
import {apartamentToAddressSting} from "../addressToString";

function TenantIndexPage() {
    const auth = useAuth()
    
    const [apartmentsLoading, setApartmentsLoading] = useState(true)
    const [apartments, setApartments] = useState<ApartmentViewModel[]>([])
    const [selectedAparment, setSelectedAparment] = useState<ApartmentViewModel>()
    
    const [smartHomeDevices, setSmartHomeDevices] = useState<SmartHomeDeviceDTO[]>()
    const [smartHomeDevicesLoadng, setSmartHomeDevicesLoadng] = useState(false)
    
    useEffect(() => {
        TenantAppartamentsService.getApiTenantappartaments().then(d => setApartments(d)).finally(() => setApartmentsLoading(false))
    }, [])
    
    useEffect(() => {
        if (apartments.length > 0 && !selectedAparment) setSelectedAparment(apartments[0])
    }, [apartments])
    
    useEffect(() => {
        if (selectedAparment) {
            setSmartHomeDevicesLoadng(true)
            SmartHomeDevicesService.getApiSmarthomedevicesApartment(selectedAparment.id!).then(d => setSmartHomeDevices(d)).finally(() => setSmartHomeDevicesLoadng(false))
        }
    }, [selectedAparment])
    
    return <motion.div variants={upVariants} initial={'init'} animate={'show'} exit={'hide'}>
        Привет, {auth.user?.userName}! <br/>
        Выбранная квартира: <select value={selectedAparment?.id} onChange={e => setSelectedAparment(apartments.find(a => a.id == parseInt(e.target.value)))}>
            {apartments.map(a => <option value={a.id}>
                {apartamentToAddressSting(a)}
            </option>)}
        </select>
        <h3>SmartHome</h3>
        <ul>
            {smartHomeDevices?.map(d => <li>
                {d.smartHomeDeviceType == SmartHomeDeviceType.INTERCOM && "Домофон"}
                {d.actions?.map(a => <button onClick={() => {
                    SmartHomeDevicesService.postApiSmarthomedevicesUse(d.id!, a.actionId!)
                }}>{a.name}</button>)}
            </li>)}
        </ul>
    </motion.div>
}

export default TenantIndexPage;