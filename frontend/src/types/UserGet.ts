import User from "./User";

type UserGet = Omit<User, 'password'>

export default UserGet