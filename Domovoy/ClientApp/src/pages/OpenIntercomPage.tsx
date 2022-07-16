import {useAuth} from "../components/AuthProvider";
import {useEffect} from "react";
import {ApplicationUserType, SmartHomeDevicesService} from "../api";
import {useParams} from "react-router-dom";

export interface Props {

}

function OpenIntercomPage(props: Props) {
    const auth = useAuth()
    const {intercomId} = useParams()
    if (auth.user?.type != ApplicationUserType.TENANT) return <>Вы не можете открывать домофоны</>
    
    useEffect(() => {
        SmartHomeDevicesService.postApiSmarthomedevicesUse(parseInt(intercomId || ""), 'open_door')
    }, [])
    
    return <>Открываем...</>
}

export default OpenIntercomPage;