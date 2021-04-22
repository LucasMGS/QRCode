import firebase from 'firebase/app';
import 'firebase/storage';

var firebaseConfig = {
	apiKey: 'AIzaSyATZ_Ece-Wa-hvrP2zqplukLxIXixxrUnQ',
	authDomain: 'qr-code-79e6c.firebaseapp.com',
	projectId: 'qr-code-79e6c',
	storageBucket: 'qr-code-79e6c.appspot.com',
	messagingSenderId: '898315589963',
	appId: '1:898315589963:web:602a67a7ddf9a347b1f0ce',
};

firebase.initializeApp(firebaseConfig);

const storage = firebase.storage();

export { storage, firebase as default };
