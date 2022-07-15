import {motion} from "framer-motion";
import {upVariants} from "../animations";
import {FormEvent, useState} from "react";
import {ApartmentState, ApartmentType, ApartmentViewModel, SerachFilters, TenantSearchService} from "../api";
import {apartamentToAddressSting} from "../addressToString";

export interface Props {

}

function TenantSearchPage(props: Props) {
    const [results, setResults] = useState<ApartmentViewModel[]>([])
    const [loading, setLoading] = useState(false)
    const [filters, setFilters] = useState<SerachFilters>({
        city: "Краснодар",
        apartmentType: undefined,
        apartmentState: undefined,
        costMax: 100000000,
        costMin: 0,
        roomCountMax: 10,
        roomCountMin: 0
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

    return <motion.div variants={upVariants} initial={'init'} animate={'show'} exit={'hide'}>
        <form onSubmit={search}>
            <input value={filters.city || ''} onChange={e => setFilters({...filters, city: e.target.value})} placeholder={"Город"}/> <br/>
            <input value={filters.costMax || ''} onChange={e => setFilters({...filters, costMax: parseInt(e.target.value)})} placeholder={"Максимальная стоимость"} type={'number'}/> <br/>
            <input value={filters.costMin || ''} onChange={e => setFilters({...filters, costMin: parseInt(e.target.value)})} placeholder={"Минимальная стоимость"} type={'number'}/> <br/>
            <input value={filters.roomCountMax || ''} onChange={e => setFilters({...filters, roomCountMax: parseInt(e.target.value)})} placeholder={"Максимальное кол-во комнат"} type={'number'}/> <br/>
            <input value={filters.roomCountMin || ''} onChange={e => setFilters({...filters, roomCountMin: parseInt(e.target.value)})} placeholder={"Минимальное кол-во комнат"} type={'number'}/> <br/>
    
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
            
            <button type={"submit"}>Поиск</button> <br/>
            
            <ul>
                {results.map(r => <li>
                    {apartamentToAddressSting(r)}
                </li>)}
            </ul>
        </form>
    </motion.div>
}

export default TenantSearchPage;