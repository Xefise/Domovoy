import {upVariants} from "../animations";
import {motion} from "framer-motion";

export interface Props {

}

function TenantChatPage(props: Props) {
    return <motion.div variants={upVariants} initial={'init'} animate={'show'} exit={'hide'}>Chat</motion.div>
}

export default TenantChatPage;