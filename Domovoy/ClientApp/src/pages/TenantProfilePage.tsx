import {upVariants} from "../animations";
import {motion} from "framer-motion";
import {useAuth} from "../components/AuthProvider";
import {useEffect, useState} from "react";
import {ApartmentViewModel, TenantAppartamentsService, TenantCartService} from "../api";
import {apartamentToAddressSting} from "../addressToString";

export interface Props {

}

function TenantProfilePage(props: Props) {
    const auth = useAuth()

    const [apartamentsLoading, setApartamentsLoading] = useState(true)
    const [apartaments, setApartaments] = useState<ApartmentViewModel[]>([])

    const [cartLoading, setCartLoading] = useState(true)
    const [cart, setCart] = useState<ApartmentViewModel[]>([])

    useEffect(() => {
        TenantAppartamentsService.getApiTenantappartaments().then(d => setApartaments(d)).finally(() => setApartamentsLoading(false))
        TenantCartService.getApiTenantcart().then(d => setCart(d)).finally(() => setCartLoading(false))
    }, [])
    
    const removeFromCart = (id: number) => {
        setCartLoading(true)
        TenantCartService.deleteApiTenantcart(id).then(() => {
            TenantCartService.getApiTenantcart().then(d => setCart(d)).finally(() => setCartLoading(false))
        })
    }
    
    return <motion.div variants={upVariants} initial={'init'} animate={'show'} exit={'hide'}>
        <h3>Профиль</h3>
        <p>{auth.user?.firstName} {auth.user?.lastName} {auth.user?.patronymic}</p>
        Ваша корзина:
        <ul>
            {cart.map(a => <li>
                {apartamentToAddressSting(a)} <button onClick={() => removeFromCart(a.id!)}>Удалить</button>
            </li>)}
        </ul>
        Ваши квартиры:
        <ul>
            {apartaments.map(a => <li>
                {apartamentToAddressSting(a)}
            </li>)}
        </ul>
    </motion.div>
}

export default TenantProfilePage;