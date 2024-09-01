import { PhotoDTO } from "./PhotoDTOs"

export interface MemberDTO {

    id: number

    username: string

    photourl: string

    age: number

    knowas: string

    createdate: Date

    lastactive: Date

    gender: string

    introduction: string

    lookingfor: string

    intrests: string

    city: string

    country: string

    photos: PhotoDTO[]

}