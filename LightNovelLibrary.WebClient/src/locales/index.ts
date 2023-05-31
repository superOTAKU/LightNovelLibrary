import {createI18n} from 'vue-i18n'
import {zh} from './zh-CN.json'
import {en} from './en.json'

const i18n = createI18n({
    locale: 'zh-CN',
    fallbackLocale: 'en',
    messages: {
        'en': en,
        'zh-CN': zh
    }
})

export default i18n
