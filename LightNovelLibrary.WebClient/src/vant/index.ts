import { App } from "vue"
import 
{
    Button,
    Col, Row,
    NavBar, Space, Tag
} 
from 'vant'
import 'vant/lib/index.css'

export module VantImporter {
    export function importVantComponents(app: App) {
        app.use(Button)
        app.use(Col)
        app.use(Row)
        app.use(NavBar)
        app.use(Space)
        app.use(Tag)
    }
}