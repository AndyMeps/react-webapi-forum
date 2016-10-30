import { combineForms } from 'react-redux-form';

const initialLogin = {
  username: '',
  password: ''
};

const initialAddTopic = {
  title: '',
  description: ''
};

const initialAddPost = {
  title: '',
  description: ''
};

export default combineForms({
    login: initialLogin,
    addTopic: initialAddTopic,
    addPost: initialAddPost
}, 'forms');