import { initializeModals, setLoginVisibility, setRegistrationVisibility } from "../../redux/reducers/modalReducer"
import store from "../shared/store"


beforeEach(() => {
    store.dispatch(initializeModals())
})
describe('modalReducer', () => {
    test('setting registration modal visibility successfully',() => {
        expect(store.getState().modalReducer).toEqual({
            registrationModal: false,
            loginModal: false
        })
        store.dispatch(setRegistrationVisibility())
        expect(store.getState().modalReducer).toEqual({
            registrationModal: true,
            loginModal: false
        })
    })
    test('setting login modal visibility successfully',() => {
        expect(store.getState().modalReducer).toEqual({
            registrationModal: false,
            loginModal: false
        })
        store.dispatch(setLoginVisibility())
        expect(store.getState().modalReducer).toEqual({
            registrationModal: false,
            loginModal: true
        })
    })
})