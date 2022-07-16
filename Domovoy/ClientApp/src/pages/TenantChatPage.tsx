import {upVariants} from "../animations";
import {motion} from "framer-motion";
import {Link} from "react-router-dom";

import Container from 'react-bootstrap/Container';
import '../styles/menu.css';

export interface Props {

}

function TenantChatPage(props: Props) {
    return <motion.div variants={upVariants} initial={'init'} animate={'show'} exit={'hide'}>

    <Container>
        <div className="previousPage">
            <Link to={'/'} className="nav_link"><span className="back">&lt;</span> &nbsp; <b>Чат</b></Link>
        </div>
    </Container>

    </motion.div>
}

export default TenantChatPage;