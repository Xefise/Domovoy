import {useAuth} from "../components/AuthProvider";
import {useEffect, useState} from "react";
import {Link} from "react-router-dom";
import {upVariants} from "../animations";
import { motion } from "framer-motion";
import {ApartmentViewModel, TenantAppartamentsService} from "../api";
import {apartamentToAddressSting} from "../addressToString";

function TenantIndexPage() {
    const auth = useAuth()
    
    const [apartamentsLoading, setApartamentsLoading] = useState(true)
    const [apartaments, setApartaments] = useState<ApartmentViewModel[]>([])
    
    useEffect(() => {
        TenantAppartamentsService.getApiTenantappartaments().then(d => setApartaments(d)).finally(() => setApartamentsLoading(false))
    }, [])
    
    return <motion.div variants={upVariants} initial={'init'} animate={'show'} exit={'hide'}>
        Привет, {auth.user?.userName}! <br/>
        Ваши квартиры:
        <ul>
            {apartaments.map(a => <li>
                {apartamentToAddressSting(a)}
            </li>)}
        </ul>
    </motion.div>
}

export default TenantIndexPage;