import {upVariants} from "../animations";
import {motion} from "framer-motion";

export interface Props {

}

function TenantProfilePage(props: Props) {
    return <motion.div variants={upVariants} initial={'init'} animate={'show'} exit={'hide'}>Test</motion.div>
}

export default TenantProfilePage;