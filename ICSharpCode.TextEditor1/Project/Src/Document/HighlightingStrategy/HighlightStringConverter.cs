using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ICSharpCode.TextEditor.Document
{
    public class HighlightStringConverter : StringConverter
    {
        // Token: 0x0600008B RID: 139 RVA: 0x00002242 File Offset: 0x00001242
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        // Token: 0x0600008C RID: 140 RVA: 0x00002242 File Offset: 0x00001242
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        // Token: 0x0600008D RID: 141 RVA: 0x0000498D File Offset: 0x0000398D
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new TypeConverter.StandardValuesCollection(HighlightingManager.Manager.HighlightingDefinitions.Keys);
        }
    }
}
