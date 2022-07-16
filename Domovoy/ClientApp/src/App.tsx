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
import TenantSearchPage from "./pages/TenantSearchPage";
import TenantProfilePage from "./pages/TenantProfilePage";
import TenantChatPage from "./pages/TenantChatPage";
import OpenIntercomPage from "./pages/OpenIntercomPage";
import AgentLayout from "./pages/AgentLayout";
import AgentIndexPage from "./pages/AgentIndexPage";

function App() {
    const location = useLocation();
    
    const key = location.pathname.includes("login")
        ? "login" 
        : location.pathname.includes("logout")
            ? "logout"
            : "main"
    
    console.log(key)

    return (
        <AuthProvider>
            <AnimatePresence exitBeforeEnter>
                <Routes key={key} location={location}>
                    <Route key={key} path="/" element={
                        <TypeSwitch
                            tenant={<TenantLayout/>}
                            constructionCompanyAdmin={<CompanyAdminLayout/>}
                            serviceProvider={<></>}
                            agent={<AgentLayout/>}
                            nonAuntificated={<Navigate to={'login'}/>}/>}
                    >
                        <Route path={""} element={
                            <TypeSwitch
                                tenant={<TenantIndexPage/>}
                                constructionCompanyAdmin={<CompanyAdminIndexPage/>}
                                serviceProvider={<></>}
                                agent={<AgentIndexPage/>}
                                nonAuntificated={<Navigate to={'login'}/>}/>
                        }>
                            <Route path={"create/complex"} element={<CreateComplexPage/>}/>
                            <Route path={"create/house/:complex"} element={<CreateApartmentHouse/>}/>
                            <Route path={"create/entrance/:house"} element={<CreateEntrancePage/>}/>
                            <Route path={"create/apartment/:house/:entrance"} element={<CreateApartmentPage/>}/>
                            <Route path={"details/apartment/:apartment"} element={<ApartamentDetails/>}/>
                        </Route>
                        <Route path={"search"} element={<TenantSearchPage/>}/>
                        <Route path={"profile"} element={<TenantProfilePage/>}/>
                        <Route path={"chat"} element={<TenantChatPage/>}/>
                    </Route>
                    <Route path="login" element={<LoginPage/>}/>
                    <Route path="logout" element={<LogoutPage/>}/>
                    <Route path="open/:intercomId" element={<AuthSwitch auntificated={<OpenIntercomPage/>} nonAuntificated={<Navigate to={"/login"}/>}/>}/>
                    <Route path="oauth">
                        <Route path="google" element={<GoogleOAuthCallback/>}/>
                    </Route>
                </Routes>
            </AnimatePresence>
        </AuthProvider>
    )
}

export default App
