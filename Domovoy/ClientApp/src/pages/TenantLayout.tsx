import React from "react";
import {AnimatePresence, motion} from "framer-motion";
import {Link, useOutlet} from "react-router-dom";
import {upVariants} from "../animations";

export interface Props {

}

function TenantLayout(props: Props) {
    const Outlet = useOutlet()
    
    return <motion.div variants={upVariants} initial={'init'} animate={'show'} exit={'hide'}>
        <AnimatePresence exitBeforeEnter>
            {Outlet && React.cloneElement(Outlet, {key: location.pathname})}
        </AnimatePresence>
        
        <nav>Тут навбар</nav>
        <Link to={''}>Main</Link>
        <Link to={'search'}>Seach</Link>
    </motion.div>
}

export default TenantLayout;