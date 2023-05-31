import { createApp } from 'vue'
import App from './App.vue'
import {VantImporter} from './vant/index.ts'
import router from './route/index.ts'
import i18n from './locales/index.ts'

const app = createApp(App)
VantImporter.importVantComponents(app)
app.use(router)
app.use(i18n)
app.mount('#app')
