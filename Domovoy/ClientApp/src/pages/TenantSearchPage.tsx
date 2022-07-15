import { motion } from "framer-motion";
import {upVariants} from "../animations";

export interface Props {

}

function TenantSearchPage(props: Props) {
    return <motion.div variants={upVariants} initial={'init'} animate={'show'} exit={'hide'}>Test</motion.div>
}

export default TenantSearchPage;