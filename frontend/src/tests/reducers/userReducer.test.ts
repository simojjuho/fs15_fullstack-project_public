import { getAllUsers, loginUser, registerUser } from "../../redux/reducers/userReducer"
import store from "../shared/store"
import server from '../servers/userServer'
import newUser from "../data/users/newUser"

beforeAll(() => {
    server.listen()
})
afterAll(() => {
    server.close()
})

describe('testing userReducer', () => {
    test('fetching users succesfully', async () => {
        await store.dispatch(getAllUsers())
        const userState = store.getState().userReducer.users
        expect(userState).toHaveLength(3)
    })
    test('registering enew users succesfully', async () => {
        await store.dispatch(registerUser(newUser))
        const userState = store.getState().userReducer.users
        expect(userState).toHaveLength(4)
        expect(userState[3].id).toBe('12345')
    })
    test('Logging in succesfully', async () => {
        await store.dispatch(loginUser({email: 'harry@potter.com', password: 'harry91'}))
        expect(store.getState().userReducer.user?.email).toBe('harry@potter.com')
    })
})

export {}