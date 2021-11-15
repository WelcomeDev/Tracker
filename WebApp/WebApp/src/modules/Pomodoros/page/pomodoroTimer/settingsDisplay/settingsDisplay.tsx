import { IconButton } from "../../../../../components/input/iconButton";

export function SettingsDisplay() {
    return (
       <section>
           <section className={'actions'}>
               <IconButton
                   className={'save-button'}
                   title={'Save'}
                   src={'mdi:check-bold'}/>
               <IconButton
                   className={'cancel-button'}
                   title={'Cancel'}
                   src={'mdi:close-thick'}/>
               <IconButton
                   title={'Remove'}
                   className={'remove-button'}
                   src={'mdi:delete-forever'}/>
           </section>
       </section>
    )
}
