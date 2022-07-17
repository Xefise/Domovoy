import {AnimatePresence, motion} from "framer-motion";
import {upVariants} from "../animations";
import {Link} from "react-router-dom";
import {FormEvent, useState} from "react";
import {
    ApartmentState,
    ApartmentType,
    ApartmentViewModel,
    SerachFilters,
    TenantCartService,
    TenantSearchService
} from "../api";
import {apartamentToAddressSting} from "../addressToString";

import Container from 'react-bootstrap/Container';
import Dropdown from 'react-bootstrap/Dropdown';
import '../styles/SearchPage.scss';
import '../styles/menu.scss';

import reject from '../images/reject.png';
import add from '../images/add.png';
import Card from "../components/Card";

export interface Props {

}

function TenantSearchPage(props: Props) {
    const [results, setResults] = useState<ApartmentViewModel[]>([])
    const [loading, setLoading] = useState(false)
    const [filters, setFilters] = useState<SerachFilters>({
        city: "Краснодар",
        apartmentType: undefined,
        apartmentState: undefined,
        costMin: 0,
        costMax: 0,
        roomCountMin: 0,
        roomCountMax: 0
    })
    const [changed, setChanged] = useState(false)
    const [searchId, setSearchId] = useState(0)
    
    const search = () => {
        let submitBtn = document.getElementById("dropdown_menu");
        submitBtn?.classList.remove('show');

        if (!loading) {
            setSearchId(searchId + 1)
            setResults([])
            setLoading(true)
            setChanged(false)
            TenantSearchService.postApiTenantsearch(filters)
                .then(d => setResults(d))
                .finally(() => setLoading(false))
        }
    }
    
    const addToCart = (a: ApartmentViewModel) => {
        TenantCartService.postApiTenantcart(a.id!)
        removeFromList(a)
    }
    
    const removeFromList = (a: ApartmentViewModel) => {
        setChanged(true)
        setResults(results.filter(r => r.id != a.id))
    }

    return <motion.div className={"searchPage"} variants={upVariants} initial={'init'} animate={'show'} exit={'hide'}>
        <Container>
            <div className="previousPage">
                <Link to={'/'} className="nav_link"><span className="back">&lt;</span> &nbsp; <b>Поиск</b></Link>
            </div>
            
           {/* <form onSubmit={search}>*/}

            <Dropdown>
              <Dropdown.Toggle variant="success" id="dropdown-basic" className="dropdown_toggle">
                <span className="filters_text">Фильтры</span>
              </Dropdown.Toggle>

              <Dropdown.Menu className="dropdown_menu" id="dropdown_menu">
                <label>Город</label><br/><input value={filters.city || ''} onChange={e => setFilters({...filters, city: e.target.value})} placeholder={"Город"}/> <br/>
                <label>Цена</label><br/><input className="from_to" value={filters.costMin || ''} onChange={e => setFilters({...filters, costMin: parseInt(e.target.value)})} placeholder={"От"} type={'number'}/>
                <input className="from_to" value={filters.costMax || ''} onChange={e => setFilters({...filters, costMax: parseInt(e.target.value)})} placeholder={"До"} type={'number'}/> <br/>
                <label>Кол-во комнат</label><br/><input className="from_to" value={filters.roomCountMin || ''} onChange={e => setFilters({...filters, roomCountMin: parseInt(e.target.value)})} placeholder={"От"} type={'number'}/>
                <input className="from_to" value={filters.roomCountMax || ''} onChange={e => setFilters({...filters, roomCountMax: parseInt(e.target.value)})} placeholder={"До"} type={'number'}/> <br/>
                Статус: <select value={filters.apartmentState} onChange={(e) => setFilters({...filters, apartmentState: e.target.value == "any" ? undefined : e.target.value as ApartmentState})}>
                    <option value={ApartmentState.FOR_SELL}>Для продажи</option>
                    <option value={ApartmentState.FOR_RENT}>Для аренды</option>
                    <option value={"any"}>Любой</option>
                </select> <br/>
                Тип: <select value={filters.apartmentType} onChange={(e) => setFilters({...filters, apartmentType: e.target.value == "any" ? undefined : e.target.value as ApartmentType})}>
                    <option value={ApartmentType.LIVING}>Жилое</option>
                    <option value={ApartmentType.COMMERCIAL}>Коммерческое</option>
                    <option value={"any"}>Любое</option>
                </select> <br/>
                <button className="filter_btn" onClick={search} disabled={loading}>Поиск</button> <br/>
              </Dropdown.Menu>
            </Dropdown>

            <div className={"cardsWrapper"}>
                <AnimatePresence>
                    {[...results].reverse().map((r, i) => <Card onSnap={d => d == "left" ? removeFromList(r) : addToCart(r)} apartment={r} key={r.id! + searchId.toString()} drag={i == results.length - 1}/>)}
                </AnimatePresence>
                {results.length == 0 && <p>{changed ? "Больше нет результатов" : "Нет результатов"}</p>}
            </div>
            {results.length > 0 && <div className={"buttons"}>
                <button className="card_choice last_item reject_choice" onClick={() => removeFromList(results[0])}><img className="card_choice" src={reject}/></button>
                <button className="card_choice last_item add_choice" onClick={() => addToCart(results[0])}><img className="card_choice" src={add}/></button>
            </div>}

{/*            </form>*/}
        </Container>
    </motion.div>
}

export default TenantSearchPage;