import {motion} from "framer-motion";
import {upVariants} from "../animations";
import {Link} from "react-router-dom";
import {FormEvent, useState} from "react";
import {ApartmentState, ApartmentType, ApartmentViewModel, SerachFilters, TenantSearchService} from "../api";
import {apartamentToAddressSting} from "../addressToString";

import Container from 'react-bootstrap/Container';
import Dropdown from 'react-bootstrap/Dropdown';
import '../styles/SearchPage.scss';
import '../styles/menu.css';

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
    
    const search = (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault()
        if (!loading) {
            setLoading(true)
            TenantSearchService.postApiTenantsearch(filters)
                .then(d => setResults(d))
                .finally(() => setLoading(false))
        }
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

              <Dropdown.Menu className="dropdown_menu">
                <label>Город</label><br/><input value={filters.city || ''} onChange={e => setFilters({...filters, city: e.target.value})} placeholder={"Город"}/> <br/>
                <label>Цена</label><br/><input className="from_to" value={filters.costMin || ''} onChange={e => setFilters({...filters, costMin: parseInt(e.target.value)})} placeholder={"От"} type={'number'}/>
                <input className="from_to" value={filters.costMax || ''} onChange={e => setFilters({...filters, costMax: parseInt(e.target.value)})} placeholder={"До"} type={'number'}/> <br/>
                <label>Кол-во комнат</label><br/><input className="from_to" value={filters.roomCountMin || ''} onChange={e => setFilters({...filters, roomCountMin: parseInt(e.target.value)})} placeholder={"От"} type={'number'}/>
                <input className="from_to" value={filters.roomCountMax || ''} onChange={e => setFilters({...filters, roomCountMax: parseInt(e.target.value)})} placeholder={"До"} type={'number'}/> <br/>
                Статус: <select value={filters.apartmentState} onChange={(e) => setFilters({...filters, apartmentState: e.target.value as ApartmentState})}>
                    <option value={ApartmentState.FOR_SELL}>Для продажи</option>
                    <option value={ApartmentState.FOR_RENT}>Для аренды</option>
                    <option value={undefined}>Любой</option>
                </select> <br/>
                Тип: <select value={filters.apartmentType} onChange={(e) => setFilters({...filters, apartmentType: e.target.value as ApartmentType})}>
                    <option value={ApartmentType.LIVING}>Жилое</option>
                    <option value={ApartmentType.COMMERCIAL}>Комерческое</option>
                    <option value={undefined}>Любое</option>
                </select> <br/>
                <button className="filter_btn" type={"submit"}>Поиск</button> <br/>
              </Dropdown.Menu>
            </Dropdown>
            
                <ul>
                    {results.map(r => <li>
                        {apartamentToAddressSting(r)}
                    </li>)}
                </ul>

{/*            </form>*/}
        </Container>
    </motion.div>
}

export default TenantSearchPage;