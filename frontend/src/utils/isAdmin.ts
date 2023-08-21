import jwtDecode from "jwt-decode"


const isAdmin = () => {
    const token = window.localStorage.getItem('token')
    if(token) {
      try {
        const decoded = jwtDecode(token)
        if(decoded != null && typeof decoded == 'object' && 'role' in decoded) {
          return decoded.role === 'Admin' ? true : false
        }
        } catch {
          return false
        }
    }
    return false
}

export default isAdmin
