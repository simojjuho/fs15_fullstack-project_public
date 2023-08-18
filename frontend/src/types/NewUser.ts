import User from "./User";

type NewUser = Omit<User, 'role' | 'id' >

export default NewUser