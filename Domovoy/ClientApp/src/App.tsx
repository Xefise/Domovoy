import logo from './logo.svg'
import {useState} from 'react'
import {Link, Navigate, Outlet, Route, Routes, useLocation} from "react-router-dom";

import {AnimatePresence} from "framer-motion";
import TenantIndexPage from "./pages/TenantIndexPage";
import AuthProvider from "./components/AuthProvider";
import LoginPage from "./pages/LoginPage";
import AuthSwitch from "./components/AuthSwitch";
import LogoutPage from "./pages/LogoutPage";
import GoogleOAuthCallback from "./pages/GoogleOAuthCallback";
import TypeSwitch from "./components/TypeSwitch";
import CompanyAdminIndexPage from "./pages/CompanyAdminIndexPage";
import CreateComplexPage from "./pages/CreateComplexPage";
import CreateApartmentHouse from "./pages/CreateApartmentHouse";
import CreateEntrancePage from "./pages/CreateEntrancePage";
import CreateApartmentPage from "./pages/CreateApartmentPage";
import ApartamentDetails from "./pages/ApartamentDetails";
import TenantLayout from "./pages/TenantLayout";
import CompanyAdminLayout from "./pages/CompanyAdminLayout";

import 'bootstrap/dist/css/bootstrap.min.css'

function App() {
    const location = useLocation();

    return (
        <AuthProvider>
            <AnimatePresence exitBeforeEnter>
                <Routes key={location.pathname.split("create")[0].split("details")[0]} location={location}>
                    <Route path="/" element={
                        <TypeSwitch
                            tenant={<TenantLayout/>}
                            constructionCompanyAdmin={<CompanyAdminLayout/>}
                            serviceProvider={<></>}
                            agent={<></>}
                            nonAuntificated={<Navigate to={'login'}/>}/>}
                    >
                        <Route path={""} element={
                            <TypeSwitch
                                tenant={<TenantIndexPage/>}
                                constructionCompanyAdmin={<CompanyAdminIndexPage/>}
                                serviceProvider={<></>}
                                agent={<></>}
                                nonAuntificated={<Navigate to={'login'}/>}/>
                        }/>
                        
                        <Route path={"create/complex"} element={<CreateComplexPage/>}/>
                        <Route path={"create/house/:complex"} element={<CreateApartmentHouse/>}/>
                        <Route path={"create/entrance/:house"} element={<CreateEntrancePage/>}/>
                        <Route path={"create/apartment/:house/:entrance"} element={<CreateApartmentPage/>}/>
                        <Route path={"details/apartment/:apartment"} element={<ApartamentDetails/>}/>
                    </Route>
                    <Route path="login" element={<LoginPage/>}/>
                    <Route path="logout" element={<LogoutPage/>}/>
                    <Route path="oauth">
                        <Route path="google" element={<GoogleOAuthCallback/>}/>
                    </Route>
                </Routes>
            </AnimatePresence>
        </AuthProvider>
    )
}

export default App
