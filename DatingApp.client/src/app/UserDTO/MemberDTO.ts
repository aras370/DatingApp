import { PhotoDTO } from "./PhotoDTOs"

export interface MemberDTO {

    userID: number

    userName: string

    email: string

    photourl: string

    age: number

    knownas: string

    mobile: string

    registerDate: Date

    lastactive: Date

    gender: string

    introduction: string

    lookingFor: string

    intrests: string

    city: string

    country: string

    avatarName: string

    PhotoDTOs: PhotoDTO[]

    IsActiveEmail:boolean

}