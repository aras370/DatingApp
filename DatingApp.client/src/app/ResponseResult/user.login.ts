import { UserDTO } from "../UserDTO/UserDTO";

export interface IResponseResult {
  issuccess: boolean;
    message?: string;
    data?: UserDTO;  // This is optional because it may not always be present
  }