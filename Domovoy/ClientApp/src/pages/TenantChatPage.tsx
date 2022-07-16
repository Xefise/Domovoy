import {upVariants} from "../animations";
import {motion} from "framer-motion";
import {Link, useLocation, useParams} from "react-router-dom";

import Container from 'react-bootstrap/Container';
import '../styles/menu.css';
import '../styles/ChatPage.scss'

export interface Props {

}

function TenantChatPage(props: Props) {
    const { search } = useLocation();

    return <motion.div variants={upVariants} initial={'init'} animate={'show'} exit={'hide'} className={"chatPage"}>
        <Container>
            <div className="previousPage">
                <Link to={'/'} className="nav_link"><span className="back">&lt;</span> &nbsp; <b>Чат</b></Link>
            </div>
        </Container>
        
        <div className={"list"}>
            <Link className={"item"} to={"?chatId=1"}>Чат №1</Link>
            <Link className={"item"} to={"?chatId=2"}>Чат №2</Link>
        </div>
    </motion.div>
}

export default TenantChatPage;