import { validateEmail } from './utils.js';
//import { axios } from './libs/axios.min.js';

new Vue({
    el: '#login',
    data: {
        Email: '',
        Password: '',
        InvalidEmail: false
    },
    computed: {
        isSubmitDisabled() {
            let isDisabled = true;

            if (
                this.Email !== '' &&
                this.Password !== ''
            ) {
                isDisabled = false;
            }

            return isDisabled;
        }
    },
    methods: {
        SubmitForm() {
            let submit = true;

            if (!validateEmail(this.Email)) {
                this.InvalidEmail = true;
                submit = false;
            } else {
                this.InvalidEmail = false;
            }

            if (submit) {
                axios({
                    method: 'post',
                    url: '/Backend/Login',
                    data: { "Fields": this.$data }
                }).then(res => {
                    alert('Successfully submitted feedback form ');
                    this.$refs.SubmitButton.setAttribute("disabled", "disabled");
                }).catch(err => {
                    alert(`There was an error submitting your form. See details: ${err}`);
                });
            }
        }
    }
});