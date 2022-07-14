import {Address, ApartmentViewModel} from "./api";

export function addressToString (address: Address | undefined) {
    return `г. ${address?.city}, ул. ${address?.street}, д. ${address?.houseNumber}`
}

export function apartamentToAddressSting(apartament: ApartmentViewModel) {
    return `${addressToString(apartament.houseEntrance?.apartmentHouse?.address)}, кв. ${apartament.apartmentNumber}`
}