# System Prompts - Guía de Uso

Este directorio contiene diferentes System Prompts que definen el comportamiento y personalidad del agente.

## 📁 Archivos Disponibles

### 1. `SystemPrompt.txt` (Por Defecto)
**Personalidad**: Chuleta - Asistente amigable en español  
**Tono**: Informal, cercano, uso de voseo argentino  
**Ideal para**: Interacciones casuales, usuarios que prefieren español rioplatense  

**Características**:
- ✓ Explicaciones detalladas de herramientas
- ✓ Ejemplos concretos de uso
- ✓ Tono amigable y conversacional
- ✓ Instrucciones completas del patrón ReAct

---

### 2. `SystemPrompt_Technical.txt` (Técnico - English)
**Personalidad**: Technical Assistant  
**Tono**: Profesional, técnico, formal  
**Ideal para**: Entornos corporativos, documentación técnica, usuarios que prefieren inglés  

**Características**:
- ✓ Lenguaje técnico preciso
- ✓ Enfoque en mejores prácticas
- ✓ Ejemplos de arquitectura
- ✓ Consideraciones de diseño

---

### 3. `SystemPrompt_Minimal.txt` (Minimalista)
**Personalidad**: Asistente conciso  
**Tono**: Directo, sin rodeos  
**Ideal para**: Usuarios avanzados, escenarios con límite de tokens, testing  

**Características**:
- ✓ Instrucciones mínimas
- ✓ Sin ejemplos extensos
- ✓ Menor consumo de tokens
- ✓ Respuestas más directas

---

## 🔧 Cómo Cambiar el System Prompt

### Opción 1: Editar `appsettings.json`

```json
{
  "AppSettings": {
    "SystemPromptPath": "Prompts/SystemPrompt_Technical.txt"
  }
}
```

### Opción 2: Variable de Entorno

```bash
# Windows (PowerShell)
$env:AppSettings__SystemPromptPath="Prompts/SystemPrompt_Minimal.txt"

# Linux/Mac
export AppSettings__SystemPromptPath="Prompts/SystemPrompt_Technical.txt"
```

### Opción 3: Crear Tu Propio Prompt

1. Crea un nuevo archivo `.txt` en este directorio
2. Escribe tu prompt personalizado
3. Actualiza `appsettings.json` con la ruta

**Ejemplo**: `SystemPrompt_Custom.txt`

---

## 📝 Plantilla para Crear Prompts Personalizados

```text
[Descripción de personalidad y rol del asistente]

🛠️ HERRAMIENTAS DISPONIBLES:

1. **Wikipedia** (search_wikipedia_titles, get_wikipedia_article):
   [Descripción...]

2. **Base de Datos** (query_database):
   [Descripción...]

3. **Repositorios** (svn_operation, git_operation, github_operation):
   [Descripción...]

4. **RAG** (search_documents):
   [Descripción...]

📋 INSTRUCCIONES:
- [Instrucción 1]
- [Instrucción 2]
- [Instrucción N]

💡 EJEMPLOS:
- [Ejemplo 1]
- [Ejemplo 2]
```

---

## 📊 Recomendaciones por Caso de Uso

| Caso de Uso | Prompt Recomendado | Razón |
|-------------|-------------------|-------|
| Desarrollo personal | `SystemPrompt.txt` | Tono amigable, español |
| Entorno corporativo | `SystemPrompt_Technical.txt` | Profesional, inglés |
| Testing/Debugging | `SystemPrompt_Minimal.txt` | Menor overhead |
| Demos públicas | `SystemPrompt_Technical.txt` | Universal, profesional |
| Usuarios argentinos | `SystemPrompt.txt` | Voseo, localizado |

---

## ⚠️ Notas Importantes

1. **Codificación**: Todos los archivos deben estar en **UTF-8** para soportar emojis y caracteres especiales
2. **Tamaño**: Mantené los prompts razonables (<4KB) para no consumir demasiados tokens
3. **Validación**: Si el archivo no existe, el sistema usa un prompt por defecto
4. **Hot Reload**: Los cambios en `appsettings.json` se recargan automáticamente, pero necesitás reiniciar la app para cambiar el prompt

---

## ✅ Mejores Prácticas

### ✓ DO:
- Usa instrucciones claras y específicas
- Incluí ejemplos concretos
- Define el tono y personalidad
- Especifica limitaciones de seguridad
- Mantené consistencia en el formato

### ✗ DON'T:
- No uses prompts demasiado largos (>8KB)
- No incluyas información sensible
- No uses formatos binarios (solo texto plano)
- No omitas las descripciones de herramientas

---

## 📚 Recursos Adicionales

- [OpenAI Prompt Engineering Guide](https://platform.openai.com/docs/guides/prompt-engineering)
- [Anthropic Claude Prompt Guide](https://docs.anthropic.com/claude/docs/prompt-engineering)
- [ReAct Pattern Paper](https://arxiv.org/abs/2210.03629)

---

**Última actualización**: v3.7.0  
**Autor**: AgentWikiChat Team
