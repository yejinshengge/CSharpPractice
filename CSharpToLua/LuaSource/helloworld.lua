--print("Hello, World!")
-- local sum = 0
-- for i = 1, 100 do
--     if i % 2 == 0 then
--         sum = sum + i
--     end
-- end
-- local t = {"a", "b", "c"}
-- t[2] = "B"
-- t["foo"] = "Bar"
-- local s = t[3] .. t[2] .. t[1] .. t["foo"] .. #t
local function max(...)
    local args = {...}
    local val, idx
    for i = 1, #args do
        if val == nil or args[i] > val then
            val, idx = args[i], i
        end
    end
    return val, idx
end

local function assert(v)
    if not v then error("断言失败") end
end

local v1 = max(3, 9, 7, 128, 35)
assert(v1 == 128)
local v2, i2 = max(3, 9, 7, 128, 35)
assert(v2 == 128 and i2 == 4)
local v3, i3 = max(max(3, 9, 7, 128, 35))
assert(v3 == 128 and i3 == 1)
local t = {max(3, 9, 7, 128, 35)}
assert(t[1] == 128 and t[2] == 4)