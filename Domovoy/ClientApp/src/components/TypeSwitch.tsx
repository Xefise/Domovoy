import {useAuth} from "./AuthProvider";
import {ReactElement} from "react";
import {ApplicationUserType} from "../api";

export interface Props {
    tenant: ReactElement,
    constructionCompanyAdmin: ReactElement,
    serviceProvider: ReactElement,
    agent: ReactElement,
    nonAuntificated: ReactElement
}

function TypeSwitch(props: Props) {
    const auth = useAuth()
    
    let element: ReactElement = <></>
    
    if (!auth.isAuthenticated) element = props.nonAuntificated
    else {
        switch (auth.user?.type) {
            case ApplicationUserType.TENANT:
                element = props.tenant
                break
            case ApplicationUserType.CONSTRUCTION_COMPANY_ADMIN:
                element = props.constructionCompanyAdmin
                break
            case ApplicationUserType.SERVICE_PROVIDER:
                element = props.constructionCompanyAdmin
                break
            case ApplicationUserType.AGENT:
                element = props.agent
                break
            default:
                element = props.nonAuntificated
        }
    }
    
    return element
}

export default TypeSwitch;