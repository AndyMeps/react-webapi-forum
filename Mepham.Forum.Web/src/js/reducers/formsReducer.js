import { combineForms } from 'react-redux-form';

const initialLogin = {
  username: '',
  password: ''
};

export default combineForms({
    login: initialLogin
}, 'forms');